import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card'
import { Button } from '@/components/ui/button'
import { Plus } from 'lucide-react'

export default function MembershipsPage() {
  return (
    <div className="space-y-6">
      <div className="flex items-center justify-between">
        <div>
          <h1 className="text-3xl font-bold">Memberships</h1>
          <p className="text-muted-foreground">
            Manage membership plans and subscriptions
          </p>
        </div>
        <Button>
          <Plus className="mr-2 h-4 w-4" />
          New Membership
        </Button>
      </div>

      <div className="grid gap-4 md:grid-cols-2">
        <Card>
          <CardHeader>
            <CardTitle>Membership Plans</CardTitle>
            <CardDescription>
              Available subscription plans
            </CardDescription>
          </CardHeader>
          <CardContent>
            <div className="text-sm text-muted-foreground">
              Membership plans list will be displayed here...
            </div>
          </CardContent>
        </Card>

        <Card>
          <CardHeader>
            <CardTitle>Active Subscriptions</CardTitle>
            <CardDescription>
              Currently active memberships
            </CardDescription>
          </CardHeader>
          <CardContent>
            <div className="text-sm text-muted-foreground">
              Active subscriptions list will be displayed here...
            </div>
          </CardContent>
        </Card>
      </div>
    </div>
  )
}
