import * as React from 'react'
import { createFileRoute } from '@tanstack/react-router'
import { ChatView } from '@/views/chatView/chatView'

export const Route = createFileRoute('/pretzelAgent')({
  component: RouteComponent,
})

function RouteComponent() {
  return <ChatView key={'pretzel'} endpoint={'pretzel'} />
}
