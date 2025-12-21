import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card'
import { Button } from '@/components/ui/button'
import { Plus } from 'lucide-react'

export default function ProgramsPage() {
  return (
    <div className="space-y-6">
      <div className="flex items-center justify-between">
        <div>
          <h1 className="text-3xl font-bold">Programs</h1>
          <p className="text-muted-foreground">
            Manage workout programs
          </p>
        </div>
        <Button>
          <Plus className="mr-2 h-4 w-4" />
          New Program
        </Button>
      </div>

      <Card>
        <CardHeader>
          <CardTitle>Workout Programs</CardTitle>
          <CardDescription>
            Available training programs
          </CardDescription>
        </CardHeader>
        <CardContent>
          <div className="text-sm text-muted-foreground">
            Program list will be displayed here...
          </div>
        </CardContent>
      </Card>
    </div>
  )
}
