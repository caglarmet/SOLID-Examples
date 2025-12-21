'use client'

import { Sidebar } from '@/components/layouts/sidebar'
import { Navbar } from '@/components/layouts/navbar'
import {
  LayoutDashboard,
  Users,
  CreditCard,
  CheckSquare,
  DollarSign,
  Calendar,
  Dumbbell,
} from 'lucide-react'

const sidebarItems = [
  {
    title: 'Dashboard',
    href: '/gym/dashboard',
    icon: LayoutDashboard,
  },
  {
    title: 'Members',
    href: '/gym/members',
    icon: Users,
  },
  {
    title: 'Memberships',
    href: '/gym/memberships',
    icon: CreditCard,
  },
  {
    title: 'Check-Ins',
    href: '/gym/check-ins',
    icon: CheckSquare,
  },
  {
    title: 'Payments',
    href: '/gym/payments',
    icon: DollarSign,
  },
  {
    title: 'Classes',
    href: '/gym/classes',
    icon: Calendar,
  },
  {
    title: 'Programs',
    href: '/gym/programs',
    icon: Dumbbell,
  },
]

export default function GymLayout({
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
