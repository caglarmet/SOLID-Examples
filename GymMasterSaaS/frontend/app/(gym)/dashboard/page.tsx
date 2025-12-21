import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card'
import { Users, CreditCard, CheckSquare, TrendingUp } from 'lucide-react'

export default function GymDashboardPage() {
  const stats = [
    {
      title: 'Total Members',
      value: '324',
      description: '+28 from last month',
      icon: Users,
    },
    {
      title: 'Active Memberships',
      value: '287',
      description: '88.6% active rate',
      icon: CreditCard,
    },
    {
      title: "Today's Check-ins",
      value: '156',
      description: '+12 from yesterday',
      icon: CheckSquare,
    },
    {
      title: 'Monthly Revenue',
      value: '$18,400',
      description: '+22% from last month',
      icon: TrendingUp,
    },
  ]

  return (
    <div className="space-y-6">
      <div>
        <h1 className="text-3xl font-bold">Gym Dashboard</h1>
        <p className="text-muted-foreground">
          Overview of your gym operations
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

      <div className="grid gap-4 md:grid-cols-2">
        <Card>
          <CardHeader>
            <CardTitle>Recent Check-ins</CardTitle>
            <CardDescription>Latest member check-ins</CardDescription>
          </CardHeader>
          <CardContent>
            <div className="text-sm text-muted-foreground">
              Recent check-ins list will be displayed here...
            </div>
          </CardContent>
        </Card>

        <Card>
          <CardHeader>
            <CardTitle>Expiring Memberships</CardTitle>
            <CardDescription>Memberships expiring soon</CardDescription>
          </CardHeader>
          <CardContent>
            <div className="text-sm text-muted-foreground">
              Expiring memberships list will be displayed here...
            </div>
          </CardContent>
        </Card>
      </div>
    </div>
  )
}
