ReleaseNumberIncrements

This code consists of a program class, a service with interface, 4 supporting data structures, and a test project with some tests on the service.

The main method in the program class specifically only takes in command line arguments and only does things based on the command line arguments. It then passes the necessary information gained from the command line arguments over to the ReleaseVersioningService which does all the heavy lifting.

The ReleaseVersioningService deserialises the json file into the ProjectDetails data structure, separates the version number into a version number data structure, increments as appropriate, then resaves the json file with the new version number. 

Currently does not deal with Major releases. Currently only works on projectdetails.json if it is in the same folder as the program.cs.

Recommended additions:
- Adding in functionality around Major Release numbers
- Adding the option of a .json file path as a command line argument so that the ReleaseVersioningService can be used on a file no matter where it's stored, alongside by default checking in the same folder as the .cs files.