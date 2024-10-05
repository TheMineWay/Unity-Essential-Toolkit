import { test, expect } from "@playwright/test";
import { APP_URL } from "../constants/app.constants";

test("has title", async ({ page }) => {
  await page.goto(APP_URL);

  await expect(page).toHaveTitle(/Unity Essential Toolkit/);
});
