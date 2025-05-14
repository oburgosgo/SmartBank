import { array, boolean, object, optional, string } from "valibot";



export const SignUpResponseSchema = object({
    success: boolean(),
    message: string(),
    errors: optional(array(string()))
});