import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card'

export default function HistoryPage() {
  return (
    <div className="space-y-6">
      <div>
        <h1 className="text-3xl font-bold">History</h1>
        <p className="text-muted-foreground">
          Your workout and check-in history
        </p>
      </div>

      <Card>
        <CardHeader>
          <CardTitle>Workout History</CardTitle>
          <CardDescription>
            All your completed workouts
          </CardDescription>
        </CardHeader>
        <CardContent>
          <div className="text-sm text-muted-foreground">
            Workout history will be displayed here...
          </div>
        </CardContent>
      </Card>
    </div>
  )
}
