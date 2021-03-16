### About FormToPDF

FromToPDF is a .NET Core (3.1) MVC Application that generates a pdf and sends it to the user together with a basic insurance calculation.

## Prerequisites

- .NET SDK
- .NET Runtime (3.1)

## Development

### Build project

    dotnet build

### Start application

    dotnet run

### Run tests

Navigate to FormToPDF.Tests and run command:

    dotnet test
    

### Sending emails

To send emails, FormToPDF uses Mailgun. Sign up on their website and create "appsettings.json" on the root level and use the following format:

```json
{
  "SmtpSettings": {
    "Host": "",
    "Port": 587,
    "UseSSL": false,

    "Credentials": {
      "Username": "",
      "Password": ""
    },
    "Auditor": ""
  },
  "Paths": {
    "ImageFolder": "images",
    "rfqFolder": "rfq",
    "documentsFolder": "documents"
  }
}
```

### Generating PDFs
If you only want to create a pdf document from user input, then you should make changes to DefaultRequestForQuotationFacade.cs and the method CreateCopyToFileSystem.
