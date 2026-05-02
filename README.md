Inheritance design
This project implements a console-based HR & Payroll System using a structured, layered architecture to ensure separation of concerns and maintainability. The system leverages inheritance by defining a base Employee class that contains shared properties such as Id, Name, and Department, along with a CalculatePay() method. This method is customized in derived classes—FullTimeEmployee and ContractEmployee—to handle different salary computations, allowing flexible and scalable payroll logic based on employee type.

LINQ usage
The application makes extensive use of LINQ for efficient data processing and analysis. Operations such as filtering, grouping, sorting, and aggregation are performed using methods like Where, GroupBy, OrderBy, Sum, and Average. These enable features like salary ranking, departmental distribution, payroll summaries, and high-earner filtering without relying on manual loops, ensuring cleaner and more optimized code.

Admin functionality
The Admin functionality provides a controlled layer for accessing advanced system insights and management features. Through authentication, only authorized users can view payroll summaries, analyze departmental data, retrieve top earners, and reset or reseed system data. This ensures both security and centralized control over critical operations, aligning with enterprise-level application design principles.
