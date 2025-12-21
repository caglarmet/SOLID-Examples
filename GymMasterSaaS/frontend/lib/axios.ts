import axios from 'axios'
import { useAuthStore } from '@/stores/auth-store'

const API_URL = process.env.NEXT_PUBLIC_API_URL || 'http://localhost:5001'

export const apiClient = axios.create({
  baseURL: API_URL,
  headers: {
    'Content-Type': 'application/json',
  },
})

// Request interceptor
apiClient.interceptors.request.use(
  (config) => {
    const { accessToken, tenantId } = useAuthStore.getState()

    if (accessToken) {
      config.headers.Authorization = `Bearer ${accessToken}`
    }

    if (tenantId) {
      config.headers['X-Tenant'] = tenantId
    }

    return config
  },
  (error) => {
    return Promise.reject(error)
  }
)

// Response interceptor
apiClient.interceptors.response.use(
  (response) => response,
  async (error) => {
    const originalRequest = error.config

    // If error is 401 and we haven't retried yet
    if (error.response?.status === 401 && !originalRequest._retry) {
      originalRequest._retry = true

      try {
        const { refreshToken, setTokens, logout } = useAuthStore.getState()

        if (!refreshToken) {
          logout()
          return Promise.reject(error)
        }

        // Attempt to refresh token
        const response = await axios.post(`${API_URL}/auth/refresh-token`, {
          refreshToken,
        })

        const { accessToken: newAccessToken, refreshToken: newRefreshToken } =
          response.data

        // Update tokens in store
        setTokens(newAccessToken, newRefreshToken)

        // Retry original request with new token
        originalRequest.headers.Authorization = `Bearer ${newAccessToken}`
        return apiClient(originalRequest)
      } catch (refreshError) {
        // Refresh failed, logout user
        useAuthStore.getState().logout()
        return Promise.reject(refreshError)
      }
    }

    return Promise.reject(error)
  }
)

export default apiClient
