import { create } from 'zustand'
import { persist } from 'zustand/middleware'

interface User {
  id: string
  fullName: string
  email: string
  role: string
}

interface AuthState {
  user: User | null
  accessToken: string | null
  refreshToken: string | null
  tenantId: string | null
  isAuthenticated: boolean

  setUser: (user: User) => void
  setTokens: (accessToken: string, refreshToken: string) => void
  setTenantId: (tenantId: string) => void
  login: (user: User, accessToken: string, refreshToken: string, tenantId: string) => void
  logout: () => void
}

export const useAuthStore = create<AuthState>()(
  persist(
    (set) => ({
      user: null,
      accessToken: null,
      refreshToken: null,
      tenantId: null,
      isAuthenticated: false,

      setUser: (user) => set({ user, isAuthenticated: true }),

      setTokens: (accessToken, refreshToken) =>
        set({ accessToken, refreshToken }),

      setTenantId: (tenantId) => set({ tenantId }),

      login: (user, accessToken, refreshToken, tenantId) =>
        set({
          user,
          accessToken,
          refreshToken,
          tenantId,
          isAuthenticated: true,
        }),

      logout: () =>
        set({
          user: null,
          accessToken: null,
          refreshToken: null,
          tenantId: null,
          isAuthenticated: false,
        }),
    }),
    {
      name: 'auth-storage',
    }
  )
)
