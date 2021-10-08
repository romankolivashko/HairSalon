# Eau Claire's Hair Salon

#### MVC web application to help salon owner manage employees (stylists) and their clients.

#### By Roman Kolivashko

## Technologies Used:
* C#
* .Net v5
* HTML
* CSS3
* Razor
* MySQL 

## User Stories

* As the salon owner, I need to be able to see a list of all stylists.

* As the salon owner, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.

* As the salon owner, I need to add new stylists to our system when they are hired.

* As the salon owner, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added.

## Setup/Installation Requirements

* _Clone this repository_ `git clone https://github.com/romankolivashko/HairSalon.git`
* _Navigate to `/HairSalon.Solution/HairSalon` directory_
* _Run `dotnet restore` command to download required dependencies_
* _Run `dotnet run` command to launch the application in a console_
* Download and install .NET Core
* Download and install MySQL Workbench
* Upon successful MySQL installation, proceed importing data:
  1. In Workbench: Select `Administration` Tab --> Under `Management` Tab 
  2. Select `Data Import/Restore` option
  3. In the pane to the right, select `Import from Self-Contained File` and navigate to this project's root directory
  4. Select `roman_kolivashko.sql` from this directory
  5. Next to `Default Target Schema` option select `New`, give the name of your liking
  6. Click `Start Import` button
  7. Create `appsettings.json` file in `/HairSalon.Solution/HairSalon` directory, make sure to append following to that file:
  ```
  {
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=<schema_name>;uid=<user>;pwd=<password>;"
   }
  }
  ```
  Note: replace *"schema_name"* with the name of file from step 5, *"user"* and *"password"* will be your local MySQL env variables.


## Known Bugs

* Refer to [the GitHub issues page](https://github.com/romankolivashko/HairSalon/issues) to see existing bugs or report new ones. 

## License

MIT
## Contact Information

rkolivashko@gmail.com