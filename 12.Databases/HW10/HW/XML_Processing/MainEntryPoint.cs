using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Processing
{
    class MainEntryPoint
    {
        const string CATALOG_FILE_NAME = "../../catalog.xml";

        const string CATALOG_ALBUM_DATA_FILE_NAME = "../../albumData.xml";

        const string INPUT_PERSON_DATA_FILE_NAME = "../../personData.txt";

        const string OUTPUT_PERSON_DATA_FILE_NAME = "../../personData.xml";

        static void Main(string[] args)
        {
            // Task01
            XmlGenerator.GenerateCatalogFile(CATALOG_FILE_NAME);

            // Task02
            XmlParser.PrintAuthorsInCatalog(CATALOG_FILE_NAME);

            // Task03
            XmlParser.PrintAuthorsInCatalogXPath(CATALOG_FILE_NAME);

            // Task04
            //XmlManupulator.DeleteExpensiveAlbums(CATALOG_FILE_NAME);

            // Task05
            XmlParser.PrintAllSongTitles(CATALOG_FILE_NAME);

            // Task06
            XmlParser.PrintAllSongTitlesWithLinq(CATALOG_FILE_NAME);

            // Task07
            XmlGenerator.GeneratePersonFromText(INPUT_PERSON_DATA_FILE_NAME, OUTPUT_PERSON_DATA_FILE_NAME);

            // Task08
            XmlGenerator.ExtractAlbumFile(CATALOG_FILE_NAME, CATALOG_ALBUM_DATA_FILE_NAME);
        }
    }
}
