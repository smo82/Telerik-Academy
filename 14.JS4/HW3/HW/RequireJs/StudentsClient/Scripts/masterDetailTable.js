define(["class"], function (Class) {
    var MasterDetailTableView = function (itemsSource, masterTemplate) {
        var table = $("<table></table>");
        var currentColumn = 0;
        var tableRow;
        var tableCell;
        for (var i = 0; i < itemsSource.length; i++) {
            tableRow = $("<tr></tr>");
            table.append(tableRow);

            tableCell = $("<td></td>");
            var item = itemsSource[i];
            tableCell.html(masterTemplate(item));

            tableRow.append(tableCell);

            currentColumn++;
        }
        return table
    };

    return {
        getMasterDetailTableView: MasterDetailTableView
    }
});