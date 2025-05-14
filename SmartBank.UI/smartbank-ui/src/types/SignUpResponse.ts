import { InferOutput } from "valibot";
import { SignUpResponseSchema } from "../schemas/sign-up.schema";

export type SignUpResponse = InferOutput<typeof SignUpResponseSchema>;