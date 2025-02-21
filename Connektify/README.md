# Connektify API

## Overview
The Connektify API is a web service built using .NET 8 and follows a Clean Architecture with Domain-Driven Design. This API is connected to a SQL database and provides CRUD operations for managing companies, contacts, and countries. It also offers various filtering and statistics features related to companies and contacts.

## Features
- **CRUD operations** for companies, contacts, and countries.
- **Filtering** contacts by country and company with the `FilterContacts` API.
- **Statistics** on company contacts by country.
- **Swagger UI** for API documentation and testing.
- **Unit tests** for ensuring functionality and stability.
- **Code-first migration** for database creation.

## Endpoints

### 1. Companies
#### `GET /api/companies`
Retrieve a list of all companies.

#### `POST /api/companies`
Create a new company.
- Request body:
    ```json
    {
      "companyName": "Test Company"
    }
    ```

#### `PUT /api/companies/{id}`
Update an existing company by ID.

#### `DELETE /api/companies/{id}`
Delete a company by ID.

### 2. Contacts
#### `GET /api/contacts`
Retrieve a list of all contacts.

#### `POST /api/contacts`
Create a new contact.

#### `PUT /api/contacts/{id}`
Update an existing contact by ID.

#### `DELETE /api/contacts/{id}`
Delete a contact by ID.

#### `GET /api/contacts/filter`
Filter contacts by countryId and/or companyId.

### 3. Countries
#### `GET /api/countries`
Retrieve a list of all countries.

#### `POST /api/countries`
Create a new country.
- Request body:
    ```json
    {
      "countryName": "Country Name"
    }
    ```

#### `PUT /api/countries/{id}`
Update an existing country by ID.

#### `DELETE /api/countries/{id}`
Delete a country by ID.

#### `GET /api/countries/statistics/{countryId}`
Get company statistics for a specific country (total contacts per company).



