'use client'

import { Sidebar } from '@/components/layouts/sidebar'
import { Navbar } from '@/components/layouts/navbar'
import {
  LayoutDashboard,
  Dumbbell,
  History,
  CreditCard,
} from 'lucide-react'

const sidebarItems = [
  {
    title: 'Dashboard',
    href: '/member/dashboard',
    icon: LayoutDashboard,
  },
  {
    title: 'Workout',
    href: '/member/workout',
    icon: Dumbbell,
  },
  {
    title: 'History',
    href: '/member/history',
    icon: History,
  },
  {
    title: 'Membership',
    href: '/member/membership',
    icon: CreditCard,
  },
]

export default function MemberLayout({
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
