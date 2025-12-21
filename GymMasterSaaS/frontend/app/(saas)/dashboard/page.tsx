import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card'
import { Building2, CreditCard, Users, TrendingUp } from 'lucide-react'

export default function SaasDashboardPage() {
  const stats = [
    {
      title: 'Total Tenants',
      value: '48',
      description: '+12% from last month',
      icon: Building2,
    },
    {
      title: 'Active Subscriptions',
      value: '42',
      description: '+8% from last month',
      icon: Users,
    },
    {
      title: 'Monthly Revenue',
      value: '$24,500',
      description: '+15% from last month',
      icon: CreditCard,
    },
    {
      title: 'Growth Rate',
      value: '+18%',
      description: 'Compared to last quarter',
      icon: TrendingUp,
    },
  ]

  return (
    <div className="space-y-6">
      <div>
        <h1 className="text-3xl font-bold">SaaS Admin Dashboard</h1>
        <p className="text-muted-foreground">
          Overview of all tenants and subscriptions
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
          <CardTitle>Recent Tenants</CardTitle>
          <CardDescription>Latest registered organizations</CardDescription>
        </CardHeader>
        <CardContent>
          <div className="text-sm text-muted-foreground">
            Recent tenants list will be displayed here...
          </div>
        </CardContent>
      </Card>
    </div>
  )
}
