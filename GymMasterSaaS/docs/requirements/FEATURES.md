# GymMasterSaaS Features

## Core Features

### 1. Multi-Tenant Management
- Tenant isolation with X-Tenant header
- Three tenant types: Demo, Trial (14 days), Paid
- Automatic tenant validation middleware
- Global query filters for data isolation

### 2. User Management
- Role-based access control (Owner, Staff, Trainer, Member)
- JWT authentication with refresh tokens
- Secure password hashing (PBKDF2)
- User registration and login

### 3. Member Management
- Member profiles (name, phone, birthdate, gender, etc.)
- Member check-in tracking
- Payment history
- Membership assignments

### 4. Membership Plans
- Customizable subscription plans
- Duration-based or entry-based plans
- Pricing management
- Active/Inactive status

### 5. Memberships
- Member subscription management
- Status tracking (Active, Expired, Frozen)
- Automatic expiration handling
- Remaining entries tracking

### 6. Check-Ins
- Quick member check-in
- Check-in history
- Time tracking

### 7. Payments
- Payment recording
- Multiple payment methods (Cash, Card, Transfer)
- Transaction tracking
- Member payment history

## Background Jobs

### 1. Membership Expiration Check (Daily)
- Automatically expires memberships past end date
- Updates membership status

### 2. Demo Account Cleanup (Daily)
- Deactivates expired demo accounts
- Maintains database hygiene

### 3. Inactive Member Notification (Weekly)
- Identifies members with no check-ins for 30+ days
- Prepares notification list (mock)

## Future Features

### Phase 2
- Email notifications
- SMS integration
- Dashboard analytics
- Reporting module
- Staff attendance tracking
- Trainer assignment
- Class scheduling
- Equipment management

### Phase 3
- Mobile app
- Online member portal
- Payment gateway integration
- Automated billing
- Contract management
- Inventory management
- CRM features
