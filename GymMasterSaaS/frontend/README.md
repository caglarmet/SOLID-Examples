# GymMasterSaaS Frontend

Modern, multi-panel frontend for GymMasterSaaS built with Next.js 14, TypeScript, and TailwindCSS.

## Features

- **3 Separate Panels**: SaaS Admin, Gym Manager, Member Portal
- **Modern UI**: Shadcn/UI components with dark/light theme
- **Type-Safe**: Full TypeScript support
- **Mobile-First**: Responsive design with TailwindCSS
- **State Management**: Zustand for global state
- **API Integration**: Axios with JWT auth & refresh token
- **Multi-Tenant**: X-Tenant header support

## Tech Stack

- **Framework**: Next.js 14 (App Router)
- **Language**: TypeScript
- **Styling**: TailwindCSS + Shadcn/UI
- **State**: Zustand
- **HTTP Client**: Axios
- **Forms**: React Hook Form + Zod
- **Icons**: Lucide React
- **Theme**: next-themes

## Project Structure

```
frontend/
├── app/
│   ├── (saas)/              # SaaS Admin Panel
│   │   ├── dashboard/
│   │   ├── tenants/
│   │   └── payments/
│   ├── (gym)/               # Gym Manager Panel
│   │   ├── dashboard/
│   │   ├── members/
│   │   ├── memberships/
│   │   ├── check-ins/
│   │   ├── payments/
│   │   ├── classes/
│   │   └── programs/
│   ├── (member)/            # Member Portal
│   │   ├── dashboard/
│   │   ├── workout/
│   │   ├── history/
│   │   └── membership/
│   ├── layout.tsx
│   ├── page.tsx
│   └── globals.css
├── components/
│   ├── layouts/
│   │   ├── sidebar.tsx
│   │   └── navbar.tsx
│   ├── ui/                  # Shadcn/UI components
│   ├── theme-provider.tsx
│   └── theme-toggle.tsx
├── lib/
│   ├── axios.ts            # API client with interceptors
│   └── utils.ts
├── stores/
│   └── auth-store.ts       # Zustand auth store
└── hooks/                   # Custom React hooks
```

## Panel Routes

### SaaS Admin Panel
- `/saas/dashboard` - Overview of all tenants
- `/saas/tenants` - Tenant management
- `/saas/payments` - Subscription payments

### Gym Manager Panel
- `/gym/dashboard` - Gym operations overview
- `/gym/members` - Member management
- `/gym/memberships` - Membership plans & subscriptions
- `/gym/check-ins` - Member check-in tracking
- `/gym/payments` - Payment management
- `/gym/classes` - Class schedules
- `/gym/programs` - Workout programs

### Member Portal
- `/member/dashboard` - Personal fitness overview
- `/member/workout` - Training programs
- `/member/history` - Workout history
- `/member/membership` - Membership details

## Getting Started

### Prerequisites

- Node.js 18+
- npm or yarn

### Installation

```bash
# Install dependencies
npm install

# Copy environment variables
cp .env.local.example .env.local

# Update API URL in .env.local
NEXT_PUBLIC_API_URL=http://localhost:5001
```

### Development

```bash
# Run development server
npm run dev

# Open http://localhost:3000
```

### Build

```bash
# Build for production
npm run build

# Start production server
npm start
```

## Environment Variables

```env
NEXT_PUBLIC_API_URL=http://localhost:5001
NEXT_PUBLIC_APP_NAME=GymMasterSaaS
NEXT_PUBLIC_ENABLE_SENTRY=false
```

## Authentication Flow

1. User logs in via `/auth/login`
2. API returns `accessToken`, `refreshToken`, `user`, `tenantId`
3. Tokens stored in Zustand store (persisted to localStorage)
4. Every API request includes:
   - `Authorization: Bearer {accessToken}`
   - `X-Tenant: {tenantId}`
5. If access token expires (401):
   - Auto-refresh using refresh token
   - Retry original request
   - If refresh fails, logout user

## Axios Interceptors

### Request Interceptor
- Adds `Authorization` header with JWT token
- Adds `X-Tenant` header with tenant ID

### Response Interceptor
- Handles 401 errors
- Auto-refreshes expired tokens
- Retries failed requests

## State Management

### Auth Store (Zustand)

```typescript
interface AuthState {
  user: User | null
  accessToken: string | null
  refreshToken: string | null
  tenantId: string | null
  isAuthenticated: boolean

  login: (user, accessToken, refreshToken, tenantId) => void
  logout: () => void
  setTokens: (accessToken, refreshToken) => void
}
```

## Theme Support

- Light/Dark mode toggle
- System preference detection
- Persisted to localStorage
- Smooth transitions

## UI Components

All components use Shadcn/UI with TailwindCSS:
- Button
- Card
- Dropdown Menu
- Dialog
- Label
- Select
- Switch
- Tabs
- Toast

## Mobile Responsiveness

- Mobile-first design
- Responsive grid layouts
- Collapsible sidebar (planned)
- Touch-friendly UI elements

## Future Enhancements

- [ ] Form components with validation
- [ ] Data tables with search/filter/pagination
- [ ] Real API integration
- [ ] Protected routes
- [ ] Loading states
- [ ] Error boundaries
- [ ] Toast notifications
- [ ] File upload
- [ ] Charts and analytics
- [ ] PWA support

## License

MIT

## Author

GymMasterSaaS Team
