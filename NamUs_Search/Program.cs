using System;
using System.Collections.Generic;
using System.Net.Http;
using OpenQA.Selenium.Chrome;

namespace NamUs_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            scrapePage("157");
        }

        private static void scrapePage(string caseNumber)
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://www.namus.gov/MissingPersons/Case#/"+ caseNumber;
            string missingAge = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[4]/div/div[2]/div[1]/div[1]");
            string currentAge = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[4]/div/div[2]/div[1]/div[2]");
            string firstName = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[4]/div/div[2]/div[2]/div[1]");
            string middleName = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[4]/div/div[2]/div[2]/div[2]");
            string lastName = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[4]/div/div[2]/div[2]/div[3]");
            string nickname = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[4]/div/div[2]/div[3]/div");
            string sex = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[4]/div/div[2]/div[5]/div");
            string height = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[4]/div/div[2]/div[6]/div[1]");
            string weight = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[4]/div/div[2]/div[6]/div[2]");
            string race = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[4]/div/div[2]/div[7]/div");
            string dlc = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[5]/div/div[4]/div[1]/div[1]");
            string location = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[5]/div/div[4]/div[3]/div[1]");
            string county = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[5]/div/div[4]/div[3]/div[2]");
            string mtl = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[5]/div/div[4]/div[4]/div[1]");
            string rtl = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[5]/div/div[4]/div[4]/div[2]");
            string cod = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[5]/div/div[4]/div[5]/div");
            string hairColor = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[6]/div/div[2]/div[1]/div");
            string headHairDescription = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[6]/div/div[2]/div[2]/div");
            string bodyHairDescription = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[6]/div/div[2]/div[3]/div");
            string facialHairDescription = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[6]/div/div[2]/div[4]/div");
            string leftEyeColor = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[6]/div/div[2]/div[5]/div[1]");
            string rightEyeColor = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[6]/div/div[2]/div[5]/div[2]");
            string eyeDescription = getVals(driver, "/html/body/div[1]/div[4]/div/div/section/div[1]/div[2]/div/div/section/div/div/article[1]/div/div[6]/div/div[2]/div[6]/div");
        }

        private static string getVals(ChromeDriver driver, string xPath)
        {
            string[] value = driver.FindElementByXPath(xPath).Text.Split("\r\n");
            return value[1];
        }
    }

    class Person
    {
        public Person(string missingAge, string currentAge, string firstName, string middleName, string lastName, 
            string nickname, string sex, string height, string weight, string race, string dlc, string location,
            string county, string mtl, string rtl, string cod, string hairColor, string headHairDescription,
            string bodyHairDescription, string facialHairDescription, string leftEyeColor, string rightEyeColor,
            string eyeDescription)
        {
            string MissingAge = missingAge;
            string CurrentAge = currentAge;
            string FirstName = firstName;
            string MiddleName = middleName;
            string LastName = lastName;
            string Nickname = nickname;
            string Sex = sex;
            string Height = height;
            string Weight = weight;
            string Race = race;
            string DLC = dlc;
            string Location = location;
            string County = county;
            string MTL = mtl;
            string RTL = rtl;
            string COD = cod;
            string HairColor = hairColor;
            string HeadHairDescription = headHairDescription;
            string BodyHairDescription = bodyHairDescription;
            string FacialHairDescription = facialHairDescription;
            string LeftEyeColor = leftEyeColor;
            string RightEyeColor = rightEyeColor;
            string EyeDescription = eyeDescription;
        }
    }
}
