# Guesthouse Booking Database

This repository contains the database structure and normalization levels for a guesthouse booking system. The database consists of several tables representing different entities and their relationships.

## Table Structure

### Entities and Fields

#### Booking
- BID (Booking ID)
- BDate (Booking Date)
- BPrice (Booking Price)
- CID (Customer ID)
- SID (Staff ID)

Example Booking Instances:

| BID  | BDate       | BPrice | CID  | SID  |
|------|-------------|--------|------|------|
| B001 | 2023-08-25  | 30$    | c001 | s001 |
| B002 | 2023-08-26  | 45$    | c002 | s002 |

#### Customer
- CID (Customer ID)
- CName (Customer Name)
- Tel (Telephone)

Example Customer Instances:

| CID  | CName    | Tel       |
|------|----------|-----------|
| c001 | Alice    | 123456789 |
| c002 | Bob      | 987654321 |

#### Staff
- SID (Staff ID)
- SName (Staff Name)
- Position (Staff Position)

Example Staff Instances:

| SID  | SName   | Position  |
|------|---------|-----------|
| s001 | Alice   | Manager   |
| s002 | Bob     | Reception |

#### Room
- RID (Room ID)
- Status (Room Status)
- RTID (Room Type ID)

Example Room Instances:

| RID  | Status  | RTID  |
|------|---------|-------|
| 101  | Occupied| r001  |
| 102  | Free    | r002  |

#### RoomType
- RTID (Room Type ID)
- RTName (Room Type Name)
- Price (Room Type Price)

Example RoomType Instances:

| RTID | RTName  | Price |
|------|---------|-------|
| r001 | 2-bed   | 50    |
| r002 | 1-bed   | 30    |

#### BookingDetails
- CheckInDate (Check-In Date)
- CheckOutDate (Check-Out Date)
- Amount (Booking Amount)
- BID (Booking ID)
- RID (Room ID)

Example BookingDetails Instances:

| CheckInDate | CheckOutDate | Amount | BID  | RID  |
|-------------|--------------|--------|------|------|
| 2023-08-25  | 2023-08-30   | 100    | B001 | 101  |
| 2023-08-26  | 2023-08-28   | 80     | B002 | 102  |

## Normalization Levels

### UNF (Unnormalized Form)

Attributes include various fields from the entities mentioned above.

### 1NF (First Normal Form)

- **Master Table (Booking)**: One booking instance per transaction.
- **Detail Table (BookingDetails)**: Multiple detail instances related to one booking.

### 2NF (Second Normal Form)

- **Room Table (Room)**: Contains only room-specific attributes.
- **RoomType Table (RoomType)**: Contains only room type-specific attributes.
- **BookingDetail Table (BookingDetails)**: Contains attributes related to booking details.

### 3NF (Third Normal Form)

- **Booking Table (Booking)**: Contains only booking-specific attributes.
- **Customer Table (Customer)**: Contains only customer-specific attributes.
- **Staff Table (Staff)**: Contains only staff-specific attributes.

## Usage

The SQL code snippets provided in this README can be used to create the necessary tables in your preferred database management system. You can adapt and extend the code to match your application's requirements.

## License

This project is licensed under the [MIT License](LICENSE).
