# The Global Project

## Purpose:

The idea behind this project is simple.  The only items contained within it have no dependency with any other project throughout the solution.  This solution is referenced in all solutions sharing its items, methods and enumerations.  The benefit is that the enumerations or classes referenced in the data layer can also be used all the way through the web project.  There is no need to reference the data layer model directly in the web project in order to reference it.

In the case of SAM, another benefit is the concept of the Composite Key.  This key does not exist in any table and is used to identify a specific application by the person ID, the application ID and list ID.  This concept is used in the grid in order to simplify determining, and differentiating, each row.  From the global project, we can add the property to the DTO and access the methods related to building the property or getting its parts even in the logic projects or web project.

Also, I included the Predicate Builder class there in order to have access to it inside the web project as well as within the logic.  I am not sure this wouldn't be more appropriate to limit to the logic projects since this is literally a logic-related set of methods.



## Thoughts:

When looking at examples in Microsoft solutions, they opt to use more projects than before.  Where we would use a single project for Common with folders having Services, Models, etc., they would break it apart into more projects and fewer folders.  I think I read that this approach was adopted when the speed of building projects jumped.  I don't have any preference, but have found that the naming becomes easier to find what you look for or where to put things.

The only gripe I have with any of this - which would apply to the project folder approach as well - is when including them in the global usings file, I added them all.  However, I bet there is a method to handle this automatically.