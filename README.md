# Library Book Items CRUD Application 

This ReadMe follows the following structure:
- [Introduction](#introduction)
- [Diagrams](#diagrams)
- [Wireframes and Screen Designs](#wireframes-and-screen-designs)
- [How to run and clone this project](#running-and-cloning-this-project)
- [Risk assessment](#risk-assessment)

# Domain For My Library Item Application
 ### Try out my application [here](https://zakiyahlibrarywebapp.azurewebsites.net/LibItemsFrontend.html)
 https://zakiyahlibrarywebapp.azurewebsites.net/LibItemsFrontend.html
# Introduction 
This is a simple C# CRUD application based on library book items which involves a frontend website (created using HTML and JS) communicating with a database using a REST API. The user is able to create, update, search and delete a library item. 

## Tools Used

- Visual Studio
- Visual Studio Code
- Git
- Azure DevOps
- Microsoft SQL Server Management Studio

## Languages Used

- C# was used to create the CRUD application in Visual Studio
- HTML, CSS, JavaScript was used to create the frontend of the project in Visual Studio Code
- TSQL 

# Diagrams

### Use Case Diagram
![Use case image](./images/use_case.png)

### Entity Relationship Diagram 

This entity relationship shows the relationship between my database.
![Entity Relationship diagram](./images/ER%20Diagram.png)

Below I have explained why my database and the tables within it are part of a one-to-many relationship.
![Entity Relationship diagram with explanation](./images/ER%20Diagram%20Explanation.png)
## Wireframes and Screen Designs
These screens were created in Adobe XD.
When designing these screens, the Fibonnacci sequence and the [Golden Ratio](https://clevelanddesign.com/insights/the-nature-of-design-the-fibonacci-sequence-and-the-golden-ratio/#:~:text=The%20Golden%20Ratio%20is%20a,subconscious%20mind%20is%20attracted%20to.) was used in order to create a visually appealing website and pleasing more enjoyable user experience,.

The icons used in these designs were taken from https://fonts.google.com/icons which is a free icon library provided by Google.

### Home and Search Screen Design:
This is the landing page, the first page that the user will see once they land onto my website. On this screen there is a collapsible form that was built using JavaScript, the user is able to add a new item by filling out this form. 

Once adding an item, it will appear in the list below and will also appear in the database.

![Home screen](./images/Search_Home%20screen.png)

### Update Screen Design:
The user is able to update their list of books by clicking on any item on the list. Once they have clicked on an item, a tick emoji will appear as well as a line striking through all of the text in that row.

Once updated, the number of days the item has been ```'checked out for'``` will change to 0, this will also be reflected in the database holding all of the library items. 

![Update screen](./images/Updated%20List%20screen.png)

### Delete Screen Design:
To delete an item, the user should hover over the item they'd like to delete and then click on the delete icon. After clicking on the delete icon, an alert dialog will appear asking the user to confirm their deletion, once the item has been deleted it will be removed from their list of library books and will also be removed from the database. 

![Delete screen](./images/Delete%20Screen.png)


# Running and Cloning This Project
Ensure you have Visual Studio Code, Visual Studio
1.	Clone the project using your preferred method (HTTPS or SSH).
2.	Open this ```./LibraryItems/LibraryItems.sln``` solution in Visual Studio
3.	Once you have the solution and running, a browser window should appear. Change the URL to ```http://localhost:5000/LibItemsFrontend.html``` 
4.	From here, the user will be able to interact with the website to add, delete, view and update their library book items

Or if you'd just like to play around with the project you can visit it [here](https://zakiyahlibrarywebapp.azurewebsites.net/LibItemsFrontend.html) :)


# Testing
Unit tests written in C# 

# Risk Assessment
Some risks encountered whilst buiding this project.
### Issues in Azure DevOps
Having 2 repos of the same project (one hosted in Azure DevOps and one in GitHub) caused me some problems. The biggest problem this gave me was whenever I was pushing new changes, it would only update the repo in GitHub and not the repo I had set up in Azure DevOps. In order to tackle this problem I ran the following commands in my terminal within the directory of this project 
- ``` git remote ```, running this command returned ```origin``` 
- then I typed in ```git remote add ADO URL-TO-MY REPO-IN-AZURE-DEVOPS-HERE```, this added a new remote pointing to the one in my DevOps
- by typing in ```git remote ``` again it should output ```ADO``` and ```origin```
- then I had typed in ```git pull ADO main``` to ensure this repo was up to date with all the changes I made that were currently only on the GitHub repo
- after typing in ```git push ADO``` the problem had been resolved and I was able to see my changes in both repos


