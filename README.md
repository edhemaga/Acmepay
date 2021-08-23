# Acmepay
The author followed instructions in the document provided. Some things such as amount vs balance check was not included as it was not mentioned in the task itself. Other auxillary functionalities were not included as the author was of opinion that those could complicate project without any real need. The project was done in a simple manner without uneccessary additional functionalities but rather only core ones needed to complete the task. 
The database was not hosted on cloud services as proper cloud service couldn't be found.
If the functionality is to be test I recommend creating a local copy of the database. In the Visual Studio it can be done by opening Package Manage Console and selecting Acmepay.Infrastructure as Default Project. 
Running "add-migration migration_name"  and "update-database" commands respecitevly would create schema and create database. Also, if there are any problems with creating the database appsettings.json file could be reviewed and parameters for database connection can be modified.
Lastly, the routes from to back-end part should be okay, but if needed, the routes may have to be adjusted to exact localhost port.
If any there any questions or clarifications for the project itself, the author can be contacted on email edimhadzic98@gmail.com.
