// vite.config.js
import { fileURLToPath, URL } from "node:url";
import { defineConfig } from "file:///Users/josehehall89gmail.com/Desktop/codeTrash/all_spice/client/node_modules/vite/dist/node/index.js";
import vue from "file:///Users/josehehall89gmail.com/Desktop/codeTrash/all_spice/client/node_modules/@vitejs/plugin-vue/dist/index.mjs";
import vueDevTools from "file:///Users/josehehall89gmail.com/Desktop/codeTrash/all_spice/client/node_modules/vite-plugin-vue-devtools/dist/vite.mjs";
var __vite_injected_original_import_meta_url = "file:///Users/josehehall89gmail.com/Desktop/codeTrash/all_spice/client/vite.config.js";
var vite_config_default = defineConfig({
  plugins: [vue(), vueDevTools()],
  resolve: {
    alias: {
      "@": fileURLToPath(new URL("./src", __vite_injected_original_import_meta_url))
    }
  },
  build: {
    outDir: "docs",
    sourcemap: false
  },
  server: {
    port: 8080
  }
  // NOTE If deploying to gh-pages uncomment the line below (https://vitejs.dev/config/shared-options.html#base)
  // base: '/all_spice/'
});
export {
  vite_config_default as default
};
//# sourceMappingURL=data:application/json;base64,ewogICJ2ZXJzaW9uIjogMywKICAic291cmNlcyI6IFsidml0ZS5jb25maWcuanMiXSwKICAic291cmNlc0NvbnRlbnQiOiBbImNvbnN0IF9fdml0ZV9pbmplY3RlZF9vcmlnaW5hbF9kaXJuYW1lID0gXCIvVXNlcnMvam9zZWhlaGFsbDg5Z21haWwuY29tL0Rlc2t0b3AvY29kZVRyYXNoL2FsbF9zcGljZS9jbGllbnRcIjtjb25zdCBfX3ZpdGVfaW5qZWN0ZWRfb3JpZ2luYWxfZmlsZW5hbWUgPSBcIi9Vc2Vycy9qb3NlaGVoYWxsODlnbWFpbC5jb20vRGVza3RvcC9jb2RlVHJhc2gvYWxsX3NwaWNlL2NsaWVudC92aXRlLmNvbmZpZy5qc1wiO2NvbnN0IF9fdml0ZV9pbmplY3RlZF9vcmlnaW5hbF9pbXBvcnRfbWV0YV91cmwgPSBcImZpbGU6Ly8vVXNlcnMvam9zZWhlaGFsbDg5Z21haWwuY29tL0Rlc2t0b3AvY29kZVRyYXNoL2FsbF9zcGljZS9jbGllbnQvdml0ZS5jb25maWcuanNcIjtpbXBvcnQgeyBmaWxlVVJMVG9QYXRoLCBVUkwgfSBmcm9tICdub2RlOnVybCdcblxuaW1wb3J0IHsgZGVmaW5lQ29uZmlnIH0gZnJvbSAndml0ZSdcbmltcG9ydCB2dWUgZnJvbSAnQHZpdGVqcy9wbHVnaW4tdnVlJ1xuaW1wb3J0IHZ1ZURldlRvb2xzIGZyb20gJ3ZpdGUtcGx1Z2luLXZ1ZS1kZXZ0b29scydcblxuLy8gaHR0cHM6Ly92aXRlanMuZGV2L2NvbmZpZy9cbmV4cG9ydCBkZWZhdWx0IGRlZmluZUNvbmZpZyh7XG4gIHBsdWdpbnM6IFt2dWUoKSwgdnVlRGV2VG9vbHMoKV0sXG4gIHJlc29sdmU6IHtcbiAgICBhbGlhczoge1xuICAgICAgJ0AnOiBmaWxlVVJMVG9QYXRoKG5ldyBVUkwoJy4vc3JjJywgaW1wb3J0Lm1ldGEudXJsKSlcbiAgICB9XG4gIH0sXG4gIGJ1aWxkOiB7XG4gICAgb3V0RGlyOiAnZG9jcycsXG4gICAgc291cmNlbWFwOiBmYWxzZSxcbiAgfSxcbiAgc2VydmVyOiB7XG4gICAgcG9ydDogODA4MFxuICB9LFxuICAvLyBOT1RFIElmIGRlcGxveWluZyB0byBnaC1wYWdlcyB1bmNvbW1lbnQgdGhlIGxpbmUgYmVsb3cgKGh0dHBzOi8vdml0ZWpzLmRldi9jb25maWcvc2hhcmVkLW9wdGlvbnMuaHRtbCNiYXNlKVxuICAvLyBiYXNlOiAnL2FsbF9zcGljZS8nXG59KVxuXG4iXSwKICAibWFwcGluZ3MiOiAiO0FBQStXLFNBQVMsZUFBZSxXQUFXO0FBRWxaLFNBQVMsb0JBQW9CO0FBQzdCLE9BQU8sU0FBUztBQUNoQixPQUFPLGlCQUFpQjtBQUo4TSxJQUFNLDJDQUEyQztBQU92UixJQUFPLHNCQUFRLGFBQWE7QUFBQSxFQUMxQixTQUFTLENBQUMsSUFBSSxHQUFHLFlBQVksQ0FBQztBQUFBLEVBQzlCLFNBQVM7QUFBQSxJQUNQLE9BQU87QUFBQSxNQUNMLEtBQUssY0FBYyxJQUFJLElBQUksU0FBUyx3Q0FBZSxDQUFDO0FBQUEsSUFDdEQ7QUFBQSxFQUNGO0FBQUEsRUFDQSxPQUFPO0FBQUEsSUFDTCxRQUFRO0FBQUEsSUFDUixXQUFXO0FBQUEsRUFDYjtBQUFBLEVBQ0EsUUFBUTtBQUFBLElBQ04sTUFBTTtBQUFBLEVBQ1I7QUFBQTtBQUFBO0FBR0YsQ0FBQzsiLAogICJuYW1lcyI6IFtdCn0K
