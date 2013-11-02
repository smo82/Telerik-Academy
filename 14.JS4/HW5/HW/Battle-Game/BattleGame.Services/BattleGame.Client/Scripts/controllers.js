/// <reference path="class.js" />
/// <reference path="data-layer.js" />
/// <reference path="ui-controls.js" />
/// <reference path="q.js" />

define(["classDef", "ui", "jquery", "q"], function (Class, UI, $, Q) {
    var Controllers = Controllers || {};

    Controllers = (function () {
        var AccessController = Class.create({
            init: function (dataPersister, mainContainerSelector) {
                this.dataPersister = dataPersister;

                this.mainContainerSelector = mainContainerSelector;
                this.loginControl = null;
                this.registerControl = null;
            },

            isUserLoggedIn: function () {
                return this.dataPersister.isUserLoggedIn();
            },

            getUserData: function () {
                return dataPersister.getUserData();
            },

            loginUser: function () {
                var loginDeferred = Q.defer();

                this.handleLoginProcedure(loginDeferred);

                return loginDeferred.promise;
            },

            logoutUser: function () {
                this.dataPersister.user.logout();
            },

            handleLoginProcedure: function (deferred) {
                var self = this;

                self.loginControl = new UI.LoginControl();

                var mainContainer = $(this.mainContainerSelector);
                mainContainer.html("");

                self.loginControl.build(this.mainContainerSelector).then(function () {
                    self.loginControl.attachLoginClickHandler(function (loginData) {
                        self.dataPersister.user.login(loginData.username, loginData.password).then(function () {
                            deferred.resolve();
                        },
                        function (error) {
                            self.loginControl.reportError(error.responseText);
                        })
                    }, true);

                    mainContainer.append("<a href='#' id='go-to-register'>Register</a>");
                    $("#go-to-register").on("click", function () {
                        self.handleRegisterProcedure(deferred);
                        return false;
                    })
                }).done();

            },

            handleRegisterProcedure: function (deferred) {
                var self = this;

                self.registerControl = new UI.RegisterControl();

                var mainContainer = $(this.mainContainerSelector);
                mainContainer.html("");

                self.registerControl.build(this.mainContainerSelector).then(function () {
                    self.registerControl.attachRegisterClickHandler(function (registerData) {
                        self.dataPersister.user.register(registerData.username, registerData.nickname, registerData.password).then(function () {
                            deferred.resolve();
                        }, function (error) {
                            self.registerControl.reportError(error.responseText);
                        });
                    }, true);

                    mainContainer.append("<a href='#' id='go-to-login'>Login</a>");
                    $("#go-to-login").on("click", function () {
                        self.handleLoginProcedure(deferred);
                        return false;
                    })
                }).done();
            }

        });

        var GameController = Class.create({
            init: function (dataPersister, mainContainerSelector) {
                this.dataPersister = dataPersister;

                this.mainContainerSelector = mainContainerSelector;

                this.openGamesList = new UI.ListControl();
                this.activeGamesList = new UI.ListControl();
                this.createdGamesList = new UI.ListControl();
                this.battleFieldGrid = new UI.BattleGameGridViewControl();
                this.createGameControl = new UI.CreateGameControl();
                this.messagesList = new UI.ListControl();
                this.makeGuessControl = new UI.GuessControl();
                this.joinGameControl = null;

                this._joinGameIndex = -1;
                this._scheduledDataUpdates = new Array();
                this._userData = {};
                this._activeGames = {};
                this._openGames = {};
                this._gameUserUnits = {};
                this._gameOpponentUnits = {};
                this._currentGameId = -1;
                this._messages = {};
                this._gridHeight = 9;
                this._gridWidth = 9;
                this._selectedElement = undefined;
            },

            startGame: function () {
                this.stopGame();
                this._userData = this.dataPersister.user.getCurrentUserData();
                var self = this;
                this.initializeControls().then(function () {
                    self.attachHandlers();
                    self.scheduleDataUpdates();
                });
            },

            initializeControls: function () {

                var self = this;

                $(this.mainContainerSelector).append("<p>Logged in as " + this._userData.nickname + " [" + this._userData.username + "]</p>");

                this.createGameControl.build(self.mainContainerSelector);

                var promisesArr = new Array();

                promisesArr.push(
                    self.openGamesList.build(self.mainContainerSelector, "Open Games", [], "title")
                );

                promisesArr.push(
                    self.activeGamesList.build(self.mainContainerSelector, "Active/Full Games", [], "title")
                );

                self.dataPersister.games.getOpen().then(function (gamesData) {
                    self.openGamesList.changeData(gamesData, "title");
                }).done();

                self.dataPersister.games.getCurrentUserActive().then(function (activeGames) {
                    var cleanActiveGames = [];
                    for (i in activeGames) {
                        if (activeGames[i].status != "open") {
                            cleanActiveGames.push(activeGames[i]);
                        }
                    }

                    self.activeGamesList.changeData(cleanActiveGames, "title");
                }).done();

                promisesArr.push(
                self.makeGuessControl.build(self.mainContainerSelector).then(function () {
                    self.makeGuessControl.hide();
                    self.battleFieldGrid.build(self.mainContainerSelector, "", ["0", "1", "2", "3", "4", "5", "6", "7", "8"], self._gridHeight, self._gridWidth, []);

                    if (self._currentGameId != -1) {
                        self.updateCurrentGame();
                    }
                })
                );

                return Q.all(promisesArr);
            },

            attachHandlers: function () {
                var self = this;

                this.createGameControl.attachCreateClickHandler(function (gameCreateData) {
                    self.dataPersister.games.create(gameCreateData.title, gameCreateData.password)
                        .then(function () {
                            self.createGameControl.clearErrorReport();
                            self.createGameControl.reportSuccess("Game created successfully and will be listed when joined");
                            self.createGameControl.clearControle();
                        }, function (error) {
                            self.createGameControl.clearErrorReport();
                            self.createGameControl.reportError(error.responseText);
                        }).done();
                });

                this.activeGamesList.attachItemClickHandler(function (itemData) {
                    var clickedActiveGameData = self._activeGames[itemData.itemIndex];

                    if (clickedActiveGameData.status == "full" && clickedActiveGameData.creator == self._userData.nickname) {
                        self.dataPersister.games.start(clickedActiveGameData.id).then(function () {
                            self._currentGameId = clickedActiveGameData.id;
                            self.updateCurrentGame();
                        });
                    }

                    else {
                        self._currentGameId = clickedActiveGameData.id;
                        self.updateCurrentGame();
                    }
                });

                this.makeGuessControl.attachGuessClickHandler(function (guessData) {
                    self.dataPersister.guesses.make(guessData.number, self._currentGameId).then(function () {
                        self.updateCurrentGame();
                    }).done();
                });

                this.openGamesList.attachItemClickHandler(function (itemData) {
                    if (self._joinGameIndex != itemData.itemIndex) {
                        if (self.joinGameControl) {
                            self.joinGameControl.deleteFromDom();
                        }

                        self._joinGameIndex = itemData.itemIndex;
                        self.joinGameControl = new UI.JoinGameControl();
                        self.joinGameControl.buildAfterContent(itemData.item)
                            .then(function () {
                                self.stopDataUpdates();

                                self.joinGameControl.attachJoinClickHandler(function (joinData) {
                                    var gameId = self._openGames[itemData.itemIndex].id;
                                    self.dataPersister.games.join(gameId, joinData.password).then(function () {
                                        self.scheduleDataUpdates();
                                        self.joinGameControl.deleteFromDom();
                                        self._joinGameIndex = -1;

                                        self._currentGameId = gameId;
                                        self.updateCurrentGame();
                                    },
                                    function (error) {
                                        self.joinGameControl.reportError(error.responseText);
                                    });
                                });
                            })
                            .done();
                    }
                });

                this.battleFieldGrid.attachBattleGridElementClickHandler(function (data) {
                    self.battleFieldGrid.clearErrorReport();
                    var clickedElement = data.clickedElement;
                    var clickedElementId = data.clickedElementId;

                    var clickedElementUnit = clickedElement.unit;

                    if (this._selectedElement) {
                        var origin = this._selectedElement;
                        this._selectedElement = undefined;
                        origin.markAsUnSelected();

                        var targetX = clickedElement.x;
                        var targetY = clickedElement.y;

                        var originX = origin.x;
                        var originY = origin.y;

                        var manhattanDistance = Math.abs(originX - targetX) + Math.abs(originY - targetY);

                        var originRange;
                        if (origin.unit.type == "warrior") {
                            originRange = 1;
                        } else {
                            originRange = 3;
                        }

                        //Target in range 
                        if (originRange >= manhattanDistance) {
                            var gameId = self._currentGameId;
                            var unitId = origin.unit.id;

                            if (jQuery.isEmptyObject(clickedElementUnit)) {
                                self.dataPersister.battle.move(gameId, unitId, targetX, targetY).then(function () {
                                    self.updateCurrentGame();
                                },
                                function (error) {
                                    self.battleFieldGrid.reportError(error.responseText);
                                });
                            } else {
                                self.dataPersister.battle.attack(gameId, unitId, targetX, targetY).then(function () {
                                    self.updateCurrentGame();
                                },
                                function (error) {
                                    self.battleFieldGrid.reportError(error.responseText);
                                });
                            }
                        }

                    } else if (!jQuery.isEmptyObject(clickedElementUnit)) {
                        clickedElement.markAsSelected();
                        this._selectedElement = clickedElement;
                    }

                    /*self.dataPersister.guesses.make(guessData.number, self._currentGameId).then(function () {
                        self.updateCurrentGame();
                    }).done();*/
                });
            },

            updateCurrentGame: function () {
                var self = this;

                this.dataPersister.games.getField(this._currentGameId).then(function (gameData) {
                    self.processCurrentGameData(gameData);
                });
            },

            //updateActiveAndCreated

            scheduleDataUpdates: function () {
                var self = this;

                this._scheduledDataUpdates.push(setInterval(function () {
                    self.dataPersister.games.getOpen().then(function (games) {
                        self._openGames = games;
                        self.openGamesList.changeData(self._openGames, "title")
                    }).done();
                }, 2000));

                this._scheduledDataUpdates.push(setInterval(function () {
                    self.dataPersister.games.getCurrentUserActive().then(function (activeGames) {
                        self.processActiveGamesData(activeGames);
                    }).done();
                }, 2000));

                this._scheduledDataUpdates.push(setInterval(function () {
                    self.dataPersister.messages.getUserUnread().then(function (messages) {
                        for (var i in messages) {
                            if (messages[i].gameId == self._currentGameId) {
                                self.updateCurrentGame();
                            }
                        }
                    }, 2000).done();
                }));
            },

            processCurrentGameData: function (gameData) {
                var userColor = "";

                if (this._userData.username == gameData.red.nickname) {
                    this._gameUserUnits = gameData.red.units;
                    this._gameOpponentUnits = gameData.blue.units;
                    userColor = "red";
                }
                else {
                    this._gameUserUnits = gameData.blue.units;
                    this._gameOpponentUnits = gameData.red.units;
                    userColor = "blue";
                }

                var gameBoard = new Array(this._gridHeight);
                for (var i = 0; i < this._gridHeight; i++) {
                    gameBoard[i] = new Array(this._gridWidth);
                    for (var j = 0; j < this._gridWidth; j++) {
                        gameBoard[i][j] = {};
                    }
                }

                var currentUnitPosition = {};
                for (var i in this._gameUserUnits) {
                    currentUnitPosition = this._gameUserUnits[i].position;
                    gameBoard[currentUnitPosition.x][currentUnitPosition.y] = this._gameUserUnits[i];
                }

                for (var i in this._gameOpponentUnits) {
                    currentUnitPosition = this._gameOpponentUnits[i].position;
                    gameBoard[currentUnitPosition.x][currentUnitPosition.y] = this._gameOpponentUnits[i];
                }

                this.battleFieldGrid.mainHeader = "Game \"" + gameData.title + "\"";
                this.battleFieldGrid.changeData(gameBoard);

                if (gameData.inTurn == userColor) {
                    this.makeGuessControl.show();
                }
                else {
                    this.makeGuessControl.hide();
                }
            },

            processActiveGamesData: function (activeGames) {
                var cleanActiveGames = [];
                for (i in activeGames) {
                    if (activeGames[i].status != "open") {
                        cleanActiveGames.push(activeGames[i]);
                    }
                }

                for (i in cleanActiveGames) {
                    if (cleanActiveGames[i].status == "full" && cleanActiveGames[i].creator == this._userData.nickname) {
                        cleanActiveGames[i].representation = cleanActiveGames[i].title + " - click to start";
                    }
                    else {
                        if (cleanActiveGames[i].id == this._currentGameId) {
                            cleanActiveGames[i].representation = cleanActiveGames[i].title + " - current game";
                        }
                        cleanActiveGames[i].representation = cleanActiveGames[i].title + " - " + cleanActiveGames[i].status;
                    }
                }

                this._activeGames = cleanActiveGames;
                this.activeGamesList.changeData(cleanActiveGames, "representation");
            },

            stopDataUpdates: function () {
                for (i in this._scheduledDataUpdates) {
                    var intervalId = this._scheduledDataUpdates[i];
                    clearInterval(intervalId);
                }
            },

            stopGame: function () {
                this.stopDataUpdates();

                this._scheduledDataUpdates = new Array();
            }
        });

        return {
            getAccessController: function (dataPersister, mainContainerSelector) { return new AccessController(dataPersister, mainContainerSelector); },
            getGameController: function (dataPersister, mainContainerSelector) { return new GameController(dataPersister, mainContainerSelector); }
        }
    }());

    return Controllers;
});