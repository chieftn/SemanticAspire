import { defineConfig } from 'vite';
import path from 'path';
import react from '@vitejs/plugin-react';

// https://vitejs.dev/config/
export default defineConfig({
    resolve: {
        alias: {
            '@': path.resolve(__dirname, './src'),
        },
    },
    plugins: [react()],
    server: {
        proxy: {
            '/api': {
                target: 'http://localhost:5350', // `http://localhost:${process.env.PORT}`, //5350
                changeOrigin: true,
                secure: false,
                // rewrite: (path) => path.replace(/^\/api/, ''),
                // target: 'http://localhost:5350',
                // changeOrigin: true,
                // rewrite: (path) => path.replace(/^\/api/, ''),
                // configure: (proxy, options) => {
                //     // proxy will be an instance of 'http-proxy'
                //   },
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
