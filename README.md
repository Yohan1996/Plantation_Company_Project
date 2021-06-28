# Plantation_Company_Project

<b>ER Diagram</b>

![image](https://user-images.githubusercontent.com/69201980/123692095-08c70a00-d874-11eb-9bd5-f35478c4f78c.png)

Assumptions of ER Diagram

Employee must have only one division but division can have more than one employee.
Employee must have only one field but field can have more than one employee.
Field must have only one division but division can have more than one field.
Employee cannot be exist without field and division.
I have assumed that field id as the unique id for the field entity. 
I have assumed that NIC no of the employee as a unique attribute because one NIC number cannot be have by another employee. 
I have assumed that working date of the employee is based on the relationship based on working field and employee.

<b>Normalized relational database schema</b>

![image](https://user-images.githubusercontent.com/69201980/123692204-27c59c00-d874-11eb-9c7b-d017f9db8fac.png)




