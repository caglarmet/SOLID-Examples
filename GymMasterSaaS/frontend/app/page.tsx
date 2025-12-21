import Link from 'next/link'
import { Button } from '@/components/ui/button'
import { Dumbbell } from 'lucide-react'

export default function HomePage() {
  return (
    <div className="flex min-h-screen flex-col items-center justify-center bg-gradient-to-br from-blue-50 to-indigo-100 dark:from-gray-900 dark:to-gray-800">
      <div className="text-center space-y-6 p-8">
        <div className="flex justify-center">
          <Dumbbell className="h-20 w-20 text-primary" />
        </div>
        <h1 className="text-5xl font-bold tracking-tight text-gray-900 dark:text-white">
          GymMasterSaaS
        </h1>
        <p className="text-xl text-gray-600 dark:text-gray-300 max-w-md mx-auto">
          Multi-tenant gym management platform
        </p>

        <div className="flex flex-col sm:flex-row gap-4 justify-center mt-8">
          <Link href="/saas/dashboard">
            <Button size="lg" variant="default">
              SaaS Admin
            </Button>
          </Link>
          <Link href="/gym/dashboard">
            <Button size="lg" variant="secondary">
              Gym Panel
            </Button>
          </Link>
          <Link href="/member/dashboard">
            <Button size="lg" variant="outline">
              Member Portal
            </Button>
          </Link>
        </div>

        <div className="mt-12 text-sm text-gray-500 dark:text-gray-400">
          <p>© 2024 GymMasterSaaS. All rights reserved.</p>
        </div>
      </div>
    </div>
  )
}
