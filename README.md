# SalaryLib


## Part A: Salary Management Lib

This C# code, SalaryLib.cs, is a class file for a library named "SalaryLib" that provides various functions and methods related to salary calculations, age calculations, and more. Here's an explanation of its main components and methods:

# SalaryLib C# Library

**Author:** Velasco Paola  
**Date:** 18 February 2022

## Overview

The `SalaryLib` is a C# library that provides a collection of methods for various salary and employee-related calculations. It offers functionalities to calculate age, validate email addresses, check Greek IBANs, determine an employee's salary scale, and more. This library is designed to be used in C# applications where such calculations are required.

## Methods and Features

### CalculateAge Method

- Calculate a person's age based on their date of birth.
- **Input:** `DateTime p_Dob`
- **Output:** Returns the person's age as an integer.

### Employee Struct

- Defines a custom struct called `Employee` to represent employee information.
- Contains properties for the employee's category, studies, work experience, and the number of children.

### validEMAIL Method

- Validate an email address using regular expressions and other checks.
- **Input:** An email address as a string.
- **Output:** Returns `true` if the email is valid, `false` if not.

### CheckIBAN Method

- Validate a Greek IBAN (International Bank Account Number).
- Check the IBAN's format and calculate whether it is valid.
- Determine which Greek bank the IBAN belongs to and return the bank's name.

### CalculateSalary Method

- Calculate an employee's gross and net salary based on their category, studies, work experience, and the number of children.
- **Input:** `Employee` object, `grossSalary`, and `netIncome` as output variables.

### CalculateMK Method

- Calculate the employee's Salary scale.
- **Input:** Employee's hiring date, studies.
- **Output:** MK, excess years, excess months, and excess days.

### NonAdultChildren Method

- Count the number of non-adult children based on their birthdates.
- **Input:** Array of children's birthdates as strings.
- **Output:** Returns the count of children under 18 years old.

### MaxNetIncome Method

- Calculate the maximum net income among an array of employees.
- **Input:** Array of `Employee` objects.
- **Output:** Returns the maximum net income.

## Usage

The `SalaryLib` library can be incorporated into C# applications for convenient salary and employee-related calculations. To use it, simply include the library in your project and call the relevant methods with the required inputs. Please refer to the code and method descriptions for specific usage details.


This library appears to provide various utility functions for working with employee data, calculating salaries, and performing other related calculations in a Greek context. It can be used in C# applications to perform these calculations.


## Part B: Unit Testing on SalaryLib
![image](https://github.com/PaolaVlsc/QualityAssurance_UnitTesting_SalaryLibManagementProject/assets/87998374/cf46e375-1dc3-461d-9e59-f9dbf26eb28b)

![image](https://github.com/PaolaVlsc/QualityAssurance_UnitTesting_SalaryLibManagementProject/assets/87998374/de365b05-2a6b-4572-a45d-c9024de6cc7e)

![image](https://github.com/PaolaVlsc/QualityAssurance_UnitTesting_SalaryLibManagementProject/assets/87998374/e3c3d3bc-b976-440a-b52f-5d146404154e)

![image](https://github.com/PaolaVlsc/QualityAssurance_UnitTesting_SalaryLibManagementProject/assets/87998374/182f988f-f078-4f79-bbfc-79c8664ef9a1)
