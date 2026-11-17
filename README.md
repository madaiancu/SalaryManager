# SalaryManager – Payroll Management System

SalaryManager is a web application developed using ASP.NET Web Forms (C#), Oracle Database, and SAP Crystal Reports.

The application provides employee management, automatic salary calculations, and payroll report generation.

## Technologies Used

- C# and ASP.NET Web Forms (.NET Framework 4.7.2)
- Oracle Database XE
- Oracle Managed Data Access (ODP.NET)
- SAP Crystal Reports
- HTML, CSS, JavaScript
- Visual Studio 2022

## Main Features

- Add, update, search, and delete employees
- Automatically calculate gross and net salaries
- Calculate CAS, CASS, and income tax
- Configure salary contribution percentages
- Automatically recalculate salaries using Oracle database triggers
- Generate payroll reports and individual salary slips
- Password-protected access to salary percentage settings
- Navigation menu and dynamically updated interface elements

## Database

The application uses Oracle Database with two main tables:

- **ANGAJATI** – stores employee information and salary details.
- **SETARI** – stores contribution percentages and password verification data.

Oracle triggers automate salary calculations whenever employee data or contribution percentages change.

## Security

Password verification uses PBKDF2 with SHA-256, a random salt, and multiple iterations.

Local database credentials and configuration files are excluded from version control.

## Project Purpose

This project was developed as part of a university master's course to demonstrate web application development, database integration, automated salary processing, and report generation.
