
# DPTaxSolution is a Tax Calculator Project

The Tax Calculator project is a .NET Core solution that provides a web-based tax calculation system using ASP.NET Core MVC and Razor Pages. It includes functionality for CRUD operations on tax records and supports different tax calculation types.

# Table of Contents

- [Overview](#overview)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Folder Structure](#folder-structure)
- [Testing](#testing)
- [Contributing](#contributing)
- [License](#license)

## Overview

The tax calculator project is designed to perform basic CRUD operations on tax records and provide various tax calculation strategies, including Fixed Rate, Fixed Value, and Progressive. It consists of multiple components:

- **TaxCalculator.Core:** Core logic, entities, and interfaces for tax calculations.
- **TaxCalculator.Data:** Data access layer using Entity Framework Core.
- **TaxCalculator.Services:** Tax calculation services implementing different strategies.
- **TaxCalculator.Web:** MVC Razor web application for user interaction.
- **TaxCalculator.Api:** API for tax calculations and data access.

## Getting Started

### Prerequisites

Make sure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (version used: 5.x)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) for data storage.

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/sb2gx/DPTaxSolution.git

2. Run and build using Visual Studio 2022

## Folder Structure
TaxCalculator.Core: Contains core logic, entities, and interfaces.
TaxCalculator.Data: Data access layer with Entity Framework migrations.
TaxCalculator.Services: Implementations of tax calculation strategies.
TaxCalculator.Web: MVC Razor web application.
TaxCalculator.Api: API for tax calculations.
TaxCalculator.Tests: Tests for tax calculations.

   
