# Data Model Project

## What is new?

When I created the data model project and added the Entity Developer files to the project, I did a little research and testing.  I removed some of the existing classes in the model because we do not use them anymore.  

I did remove the VwAttributeView from the collection.  We needed to get rid of that one as it meant we were using two separate versions of the extensions to filter the criteria.  The initial benefit of this view was that it included the "Composite Key" within the view.  Using the DTO approach, we can add this property and functionality within the DTO.

Speaking of DTO, I found DevArt already included a template to generate the DTO objects, the methods to convert to and from the model and DTO.  I have not gotten to the point of using AutoMapper, but it included partial methods for DTOs and there we can included the properties - like Composite Key.