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
	    render: function (masterTemplate) {
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