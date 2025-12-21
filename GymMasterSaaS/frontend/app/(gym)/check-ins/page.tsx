import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card'

export default function CheckInsPage() {
  return (
    <div className="space-y-6">
      <div>
        <h1 className="text-3xl font-bold">Check-Ins</h1>
        <p className="text-muted-foreground">
          Track member check-ins
        </p>
      </div>

      <Card>
        <CardHeader>
          <CardTitle>Today's Check-Ins</CardTitle>
          <CardDescription>
            Member check-in history for today
          </CardDescription>
        </CardHeader>
        <CardContent>
          <div className="text-sm text-muted-foreground">
            Check-in list will be displayed here...
          </div>
        </CardContent>
      </Card>
    </div>
  )
}
