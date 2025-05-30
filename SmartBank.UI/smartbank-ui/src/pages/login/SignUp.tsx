import { useState } from "react";
import { Button } from "../../components/ui/Button";
import { CardContent, CardFooter, CardHeader, CardTitle } from "../../components/ui/Card";
import { Input } from "../../components/ui/Input";
import { Label } from "../../components/ui/Label";
import { SignUpRequest } from "../../interfaces/SignUpRequest";
import { useAuth } from "../../hooks/useAuth";


interface SignUpProps {
    onFormChange: (form: string) => void;

}

export default function SignUp({ onFormChange }: SignUpProps) {

    const [formData, setFormData] = useState<SignUpRequest>({
        email: "",
        password: "",
        passwordConfirmed: "",
        phoneNumber: ""
    });

    const { register } = useAuth();

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {

        const { name, value } = e.target;

        setFormData(prev => ({ ...prev, [name]: value }));


    }

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {

        e.preventDefault();

        if (formData.password === formData.passwordConfirmed) {
            const registerResponse = await register(formData);

            if (registerResponse) {
                onFormChange("verify-phone")
            }
        }
    }

    return (
        <div className="flex flex-col justify-center h-full">
            <CardHeader className="space-y-1 pb-6">
                <CardTitle className="text-2xl font-bold">Sign Up</CardTitle>
            </CardHeader>
            <CardContent className="px-6 pb-4 flex-grow">
                <form onSubmit={handleSubmit}>
                    <div className="grid w-full items-center gap-4">
                        <div className="flex flex-col space-y-1.5">
                            <Label htmlFor="email">Email</Label>
                            <Input
                                id="email"
                                type="email"
                                name="email"
                                placeholder="Enter your email"
                                value={formData.email}
                                onChange={(e) => handleChange(e)}
                                required
                            />
                        </div>
                        <div className="flex flex-col space-y-1.5">
                            <Label htmlFor="password">Password</Label>
                            <Input
                                id="password"
                                type="password"
                                name="password"
                                placeholder="Create a password"
                                value={formData.password}
                                onChange={(e) => handleChange(e)}
                                required
                            />
                            {/* <PasswordStrengthMeter password={password} /> */}
                        </div>
                        <div className="flex flex-col space-y-1.5">
                            <Label htmlFor="confirm-password">Confirm Password</Label>
                            <Input
                                id="confirm-password"
                                type="password"
                                placeholder="Confirm your password"
                                name="passwordConfirmed"
                                value={formData.passwordConfirmed}
                                onChange={(e) => handleChange(e)}
                                required
                            />
                        </div>
                        <div className="flex flex-col space-y-1.5">
                            <Label htmlFor="phone">Phone Number</Label>
                            <Input
                                id="phone"
                                type="tel"
                                name="phoneNumber"
                                placeholder="Enter your phone number"
                                value={formData.phoneNumber}
                                onChange={(e) => handleChange(e)}
                                required
                            />
                        </div>
                    </div>
                    <Button className="w-full mt-4" type="submit">
                        Sign Up
                    </Button>
                </form>
            </CardContent>
            <CardFooter>
                <Button variant="link" onClick={() => onFormChange("signin")} >
                    Already have an account? Sign In
                </Button>
            </CardFooter>
        </div>
    );
}