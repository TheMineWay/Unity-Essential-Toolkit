import config from "../docusaurus.config";
import pk from "../package.json";

export const APP_URL =
  process.env.NODE_ENV === "development"
    ? "http://localhost:3000" + config.baseUrl
    : pk.homepage;
