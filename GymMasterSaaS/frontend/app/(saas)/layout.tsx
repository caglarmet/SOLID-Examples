'use client'

import { Sidebar } from '@/components/layouts/sidebar'
import { Navbar } from '@/components/layouts/navbar'
import {
  LayoutDashboard,
  Building2,
  CreditCard
} from 'lucide-react'

const sidebarItems = [
  {
    title: 'Dashboard',
    href: '/saas/dashboard',
    icon: LayoutDashboard,
  },
  {
    title: 'Tenants',
    href: '/saas/tenants',
    icon: Building2,
  },
  {
    title: 'Payments',
    href: '/saas/payments',
    icon: CreditCard,
  },
]

export default function SaasLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <div className="flex h-screen overflow-hidden">
      <Sidebar items={sidebarItems} />
      <div className="flex flex-1 flex-col overflow-hidden">
        <Navbar />
        <main className="flex-1 overflow-y-auto bg-background p-6">
          {children}
        </main>
      </div>
    </div>
  )
}
