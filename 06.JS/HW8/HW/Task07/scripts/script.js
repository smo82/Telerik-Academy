/*
Task07
Write a script that parses an URL address given in the format:

[protocol]://[server]/[resource]

and extracts from it the [protocol], [server] and [resource] elements. 
Return the elements in a JSON object.For example from the 
URL http://www.devbg.org/forum/index.php the following information should be 
extracted:

{protocol: "http", 
 server: "www.devbg.org",
 resource: "/forum/index.php"}

*/

function parseUrl(url){
	var protocolSeparator = "://";
	var indexAfterProtocol = url.indexOf(protocolSeparator);
	var protocol = url.substring(0, indexAfterProtocol);

	indexAfterProtocol = indexAfterProtocol + protocolSeparator.length;
	var indexAfterServer = url.indexOf("/", indexAfterProtocol);
	if (indexAfterServer < 0)
		indexAfterServer = url.length;
	var server = url.substring(indexAfterProtocol, indexAfterServer);

	var resource = url.substring(indexAfterServer, url.length);

	return {
		protocol : protocol,
		server : server,
		resource : resource
	}
}

var url = "http://www.devbg.org/forum/index.php";
jsConsole.writeLine("The URL is: " + url);

var parsedUrl = parseUrl(url);
jsConsole.writeLine("The protocol is: " + parsedUrl.protocol);
jsConsole.writeLine("The server is: " + parsedUrl.server);
jsConsole.writeLine("The resource is: " + parsedUrl.resource);
