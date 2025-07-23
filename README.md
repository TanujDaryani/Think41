# 🧳 Think41 Baggage Tracking API

A RESTful backend service built using **ASP.NET Core** to track baggage movement across airport gates and locations.

Designed for interview submission at **Think41**, this API supports:

- ✅ Last known location lookup (case-sensitive)
- ✅ Bags en-route to a gate
- ✅ Ranked gate statistics by baggage activity

---

## 📦 Features

| Endpoint                                | Description                                         |
|----------------------------------------|-----------------------------------------------------|
| `GET /api/baggage/scans/bag/{id}`      | Returns last known location of a specific bag       |
| `GET /api/baggage/active/gate/{gate}`  | Lists bags currently en-route to the gate           |
| `GET /api/baggage/stats/gate-counts`   | Ranks gates by number of unique bags scanned        |

---

## 🛠️ Tech Stack

- **Backend**: ASP.NET Core 8
- **Database**: In-Memory EF Core (easy to replace with SQL Server or SQLite)
- **Architecture**: Clean layered (Controllers, Services, DTOs, Models)
- **Tooling**: Swagger for API documentation

---

## ▶️ Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)

### Run Locally

```bash
git clone https://github.com/yourusername/baggage-tracking-api.git
cd baggage-tracking-api
dotnet run
Navigate to:

bash
Copy
Edit
https://localhost:5001/swagger
📁 Project Structure
rust
Copy
Edit
/Controllers      -> API endpoints
/Services         -> Business logic
/DTOs             -> Response structures
/Models           -> EF data models
/Think41DbContext -> EF Core DB setup
📌 Sample Response
GET /api/baggage/scans/bag/BAG123?latest=true
json
Copy
Edit
{
  "bagTagId": "BAG123",
  "lastLocation": "Sorter_3",
  "lastScanAt": "2025-07-23T18:59:00Z"
}
📃 License
MIT — Free for personal or commercial use.

✍️ Author
Tanuj Daryani