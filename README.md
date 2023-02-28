# AnticariApp
 Project of Stefan Nedelcu which consists in a book-exchange platform.
 ![Postings page](https://i.imgur.com/NNbekxI.png)

### Implemented functionalities

- Authentication & Authorization
- Adding book sale postings
- Searching for existing postings (simple CONTAINS search for now; MSSQL Full-Text Search could be interesting for the future)
- Viewing existing postings
- Recommendations from existing postings (based on author/genre preference you provide)
- Book wishlist

### Main technologies used:

- .NET 6 Web API, EntityFrameworkCore
- MySQL database (at the time hosted in AWS RDS free tier but no longer available)
- React & Bootstrap

### Possible improvements:

- Message Queue + Email notifications
- MSSQL migration + Full-Text Search, advanced filtering
- Better error/exception handling
- UI/UX improvements
- Typescript
