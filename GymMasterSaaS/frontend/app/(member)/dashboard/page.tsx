import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card'
import { Dumbbell, Calendar, TrendingUp, Award } from 'lucide-react'

export default function MemberDashboardPage() {
  const stats = [
    {
      title: 'Total Workouts',
      value: '42',
      description: 'This month',
      icon: Dumbbell,
    },
    {
      title: 'Days Active',
      value: '18',
      description: 'Out of 30 days',
      icon: Calendar,
    },
    {
      title: 'Progress',
      value: '+12%',
      description: 'From last month',
      icon: TrendingUp,
    },
    {
      title: 'Achievements',
      value: '8',
      description: 'Badges earned',
      icon: Award,
    },
  ]

  return (
    <div className="space-y-6">
      <div>
        <h1 className="text-3xl font-bold">Welcome Back!</h1>
        <p className="text-muted-foreground">
          Your fitness journey at a glance
        </p>
      </div>

      <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4">
        {stats.map((stat) => {
          const Icon = stat.icon
          return (
            <Card key={stat.title}>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">
                  {stat.title}
                </CardTitle>
                <Icon className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">{stat.value}</div>
                <p className="text-xs text-muted-foreground">
                  {stat.description}
                </p>
              </CardContent>
            </Card>
          )
        })}
      </div>

      <Card>
        <CardHeader>
          <CardTitle>Your Membership</CardTitle>
          <CardDescription>Current membership status</CardDescription>
        </CardHeader>
        <CardContent>
          <div className="text-sm text-muted-foreground">
            Membership details will be displayed here...
          </div>
        </CardContent>
      </Card>
    </div>
  )
}
