# AngularAndNetCoreAPI
Requirements:
Calculation of monthly premiums based on Death Cover amount, Occupation Rating Factor, and Age.
Formula provided: 
Death Premium = (Death Cover amount * Occupation Rating Factor * Age) /1000 * 12
All fields required

tech stack:
.Net core 3.1 API, Angular 8 UI, 
patterns: SOA (Onion Layer), DI, SOLID
Basic solution from VisualStudio 2019 Angular/.Netcore template
 
requirements: 
nodejs is running
angular cli installed

considerations:
Used Reactive forms for validation
UI uses bootstrap but not mobile layout
No validation of date of birth – if date is incorrect, then age is used, otherwise calculates age from dob and updates form when calculation is complete
Occupation + Ratings provided by backend API
No auto-formatting date, currency