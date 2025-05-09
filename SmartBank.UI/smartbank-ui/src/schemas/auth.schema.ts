import { object, string, number } from 'valibot';

export const TokenResponseSchema = object({
    access_token: string(),
    token_type: string(),
    expires_in: number()
});