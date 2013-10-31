using System;

class CompanyData
{
    static void Main()
    {
        Console.Write("Please enter the company name:");
        string companyName = Console.ReadLine();
        string companyNameDisplay = "Company name";

        Console.Write("Please enter the company address:");
        string companyAddress = Console.ReadLine();
        string companyAddressDisplay = "Company address";

        Console.Write("Please enter the company phone number:");
        uint companyPhoneNumber;

        while ((!uint.TryParse(Console.ReadLine(), out companyPhoneNumber)) || (companyPhoneNumber < 1000000))
        {
            Console.Write("Incorrect phone number (it should be of type long with more then 6 digits), please enter the phone number:");
        }
        string companyPhoneNumberDisplay = "Company phone number";

        Console.Write("Please enter the company fax number:");
        uint companyFaxNumber;

        while ((!uint.TryParse(Console.ReadLine(), out companyFaxNumber)) || (companyFaxNumber < 1000000))
        {
            Console.Write("Incorrect fax number (it should be of type long with more then 6 digits), please enter the fax number:");
        }
        string companyFaxNumberDisplay = "Company fax number";

        Console.Write("Please enter the company web site:");
        string companyWebSite = Console.ReadLine();
        string companyWebSiteDisplay = "Company web site";
        

        //Manager
        Console.Write("Please enter the managers first name:");
        string managerFirstName = Console.ReadLine();
        string managerFirstNameDisplay = "Managers first name";

        Console.Write("Please enter the managers last name:");
        string managerLastName = Console.ReadLine();
        string managerLastNameDisplay = "Managers last name";

        Console.Write("Please enter the managers age:");
        byte managerAge;

        while ((!byte.TryParse(Console.ReadLine(), out managerAge)) || (managerAge > 120))
        {
            Console.Write("Incorrect manager age, please enter the managers age:");
        }
        string managerAgeDisplay = "Managers age";

        Console.Write("Please enter the managers phone number:");
        uint managerPhoneNumber;

        while ((!uint.TryParse(Console.ReadLine(), out managerPhoneNumber)) || (managerPhoneNumber < 1000000))
        {
            Console.Write("Incorrect phone number (it should be of type long with more then 6 digits), please enter the phone number:");
        }
        string managerPhoneNumberDisplay = "Managers phone number";

        Console.WriteLine("{0,-30} | {1,-20}", companyNameDisplay, companyName);
        Console.WriteLine("{0,-30} | {1,-30}", companyAddressDisplay, companyAddress);
        Console.WriteLine("{0,-30} | {1,-20:(+359) ### ### ###}", companyPhoneNumberDisplay, companyPhoneNumber);
        Console.WriteLine("{0,-30} | {1,-20:(+359) ### ### ###}", companyFaxNumberDisplay, companyFaxNumber);
        Console.WriteLine("{0,-30} | {1,-30}", companyWebSiteDisplay, companyWebSite);
        Console.WriteLine("{0,-30} | {1,-20}", managerFirstNameDisplay, managerFirstName);
        Console.WriteLine("{0,-30} | {1,-20}", managerLastNameDisplay, managerLastName);
        Console.WriteLine("{0,-30} | {1,-3}", managerAgeDisplay, managerAge);
        Console.WriteLine("{0,-30} | {1,-20:(+359) ### ### ###}", managerPhoneNumberDisplay, managerPhoneNumber);
    }
}