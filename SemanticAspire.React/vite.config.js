import { defineConfig } from 'vite';
import path from 'path';
import react from '@vitejs/plugin-react';
import { TanStackRouterVite } from '@tanstack/router-plugin/vite';

// https://vitejs.dev/config/
export default defineConfig({
    resolve: {
        alias: {
            '@': path.resolve(__dirname, './src'),
        },
    },
    plugins: [TanStackRouterVite({ autoCodeSplitting: true }), react()],
    server: {
        proxy: {
            '/api': {
                target: process.env.services__apiservice__http__0,
                changeOrigin: true,
                secure: false,
            },
        },
    },
    build: {
        outDir: 'build',
        rollupOptions: {
            output: {
                entryFileNames: `[name].js`,
                chunkFileNames: `[name].js`,
                assetFileNames: `[name].[ext]`,
            },
        },
    },
});
