/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
var controls = controls || {};
(function (c) {
	var TableView = Class.create({
	    init: function (itemsSource, numberOfColumns) {
			if (!(itemsSource instanceof Array)) {
				throw "The itemsSource of a Table must be an array!";
			}
			this.itemsSource = itemsSource;
			this.numberOfColumns = numberOfColumns || 1;
		},
		render: function (template) {
		    var table = document.createElement("table");
		    var currentColumn = 0;
		    var tableRow;
		    var tableCell;
		    for (var i = 0; i < this.itemsSource.length; i++) {
		        if ((currentColumn % this.numberOfColumns) == 0) {
		            tableRow = document.createElement("tr");
		            table.appendChild(tableRow);
		        }

		        tableCell = document.createElement("td");
                var item = this.itemsSource[i];
                tableCell.innerHTML = template(item);
                tableRow.appendChild(tableCell);

                currentColumn++;
			}
		    return table.outerHTML;
		}
	});

	c.getTableView = function (itemsSource, numberOfColumns) {
	    return new TableView(itemsSource, numberOfColumns);
	}
}(controls || {}));