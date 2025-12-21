import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card'
import { Button } from '@/components/ui/button'
import { Play } from 'lucide-react'

export default function WorkoutPage() {
  return (
    <div className="space-y-6">
      <div className="flex items-center justify-between">
        <div>
          <h1 className="text-3xl font-bold">Workout</h1>
          <p className="text-muted-foreground">
            Your personalized training programs
          </p>
        </div>
        <Button>
          <Play className="mr-2 h-4 w-4" />
          Start Workout
        </Button>
      </div>

      <Card>
        <CardHeader>
          <CardTitle>Today's Workout</CardTitle>
          <CardDescription>
            Your scheduled training for today
          </CardDescription>
        </CardHeader>
        <CardContent>
          <div className="text-sm text-muted-foreground">
            Workout program will be displayed here...
          </div>
        </CardContent>
      </Card>
    </div>
  )
}
