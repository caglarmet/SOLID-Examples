import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card'
import { Button } from '@/components/ui/button'
import { CreditCard } from 'lucide-react'

export default function MembershipPage() {
  return (
    <div className="space-y-6">
      <div className="flex items-center justify-between">
        <div>
          <h1 className="text-3xl font-bold">Membership</h1>
          <p className="text-muted-foreground">
            Manage your membership and payments
          </p>
        </div>
        <Button>
          <CreditCard className="mr-2 h-4 w-4" />
          Renew Now
        </Button>
      </div>

      <Card>
        <CardHeader>
          <CardTitle>Current Membership</CardTitle>
          <CardDescription>
            Your active membership details
          </CardDescription>
        </CardHeader>
        <CardContent>
          <div className="text-sm text-muted-foreground">
            Membership details and payment history will be displayed here...
          </div>
        </CardContent>
      </Card>
    </div>
  )
}
