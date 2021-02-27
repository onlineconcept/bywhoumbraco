const { VueLoaderPlugin } = require("vue-loader");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");



module.exports = {
  output: {
    path: __dirname + "/Dev/Dev/wwwroot/",
    filename: "js/bundle.js"
  },
  module: {
    rules: [
      {
        test: /.js$/,
        exclude: ["/node_modules/","/Dev", "/ByWhoTestUmbraco"],
        use: {
          loader: "babel-loader"
        }
      },
      {
        test: /.vue$/,
        loader: "vue-loader"
      },
        {
            test: /\.s[ac]ss$/,
            use: [
                MiniCssExtractPlugin.loader,
                "css-loader", // translates CSS into CommonJS
                "sass-loader"
            ]
        },
      {
        test: /\.css$/,
        use: [
          MiniCssExtractPlugin.loader,
          "css-loader"
        ]
      },
      {
        test: /\.svg$/,
        use: [
          {
            loader: 'svg-url-loader',
            options: {
              limit: 10000,
            },
          },
        ],
      },
    ]
  },
  resolve: {
    alias: {
      vue$: "vue/dist/vue.esm.js"
    },
    extensions: ["*", ".js", ".vue", ".json"]
  },
  plugins: [
    new VueLoaderPlugin(),
    new MiniCssExtractPlugin({
      filename: "css/styles.css",
      chunkFilename: "[id].css"
    })
  ]
};
