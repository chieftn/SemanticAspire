import * as React from 'react';
import { createRootRoute, Outlet } from '@tanstack/react-router';
import { TanStackRouterDevtools } from '@tanstack/router-devtools';
import { MainLayout } from '@/shared/components/mainLayout';
import { Masthead } from '@/shared/components/masthead';
import { Footer } from '@/shared/components/footer';

export const Route = createRootRoute({
    component: () => (
        <>
            <MainLayout header={<Masthead />} body={<Outlet />} footer={<Footer />} />
            <TanStackRouterDevtools />
        </>
    ),
});
