/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
var controls = controls || {};
(function (c) {
    var MasterDetailTableView = Class.create({
	    init: function (itemsSource, numberOfColumns) {
			if (!(itemsSource instanceof Array)) {
				throw "The itemsSource of a TableView must be an array!";
			}
			this.itemsSource = itemsSource;
			this.numberOfColumns = numberOfColumns || 1;
		},
	    render: function (masterTemplate, innerTemplate) {
	        var table = $("<table></table>");
		    var currentColumn = 0;
		    var tableRow;
		    var tableCell;
		    for (var i = 0; i < this.itemsSource.length; i++) {
		        if ((currentColumn % this.numberOfColumns) == 0) {
		            tableRow = $("<tr></tr>");
		            table.append(tableRow);
		        }

		        tableCell = $("<td></td>");
                var item = this.itemsSource[i];
                tableCell.html(masterTemplate(item));
                
                tableCell.click(function () {
                    if (!$(this).hasClass('expanded')) {
                        var innerContent = document.createElement("div");
                        innerContent.innerHTML = innerTemplate(item);
                        $(innerContent).addClass("innerContent");
                        $(this).append(innerContent);
                        $(this).addClass("expanded");
                    }
                    else {
                        var innerContent = jQuery(".innerContent", $(this))[0];
                        innerContent.remove();
                        $(this).removeClass();
                    }
                });

                tableRow.append(tableCell);

                currentColumn++;
		    }
		    return table
		}
	});

	c.getMasterDetailTableView = function (itemsSource, numberOfColumns) {
	    return new MasterDetailTableView(itemsSource, numberOfColumns);
	}
}(controls || {}));