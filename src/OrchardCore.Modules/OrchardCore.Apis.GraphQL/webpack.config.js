var path = require('path');

module.exports = {
    entry: "./Assets/js/App.tsx",
    output: {
        path: path.resolve(__dirname, "wwwroot/Scripts"),
        filename: "graphiql-orchard.js"
    },
    resolve: {
        // Add `.ts` and `.tsx` as a resolvable extension.
        extensions: [".ts", ".tsx", ".js", ".mjs"]
    },
    module: {
      rules: [
        {
          test: /\.(ts|tsx)$/,
          exclude: /node_modules/,
          use: {
            loader: "ts-loader"
          }
        },
        {
            test:/\.css$/,
            use:['style-loader','css-loader']
        },
        {
          test: /\.mjs$/,
          include: /node_modules/,
          type: "javascript/auto"
        },
        { 
            test: /\.flow$/, 
            use: 'null-loader' 
        },
        {
            test: /\.(ts.map|js.map|d.ts)$/,
            use: 'null-loader'
        }
      ]
    },
    performance: {
        hints: false,
        maxEntrypointSize: 1512000,
        maxAssetSize: 1512000
    }
};
