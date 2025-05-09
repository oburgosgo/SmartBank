import { useEffect, useState } from "react";
import { useAuth } from "../../hooks/useAuth";
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "../../components/ui/Card";
import { Button } from "../../components/ui/Button";
import { Label } from "../../components/ui/Label";
import { Input } from "../../components/ui/Input";
import { useNavigate } from "react-router-dom";


export default function Login() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");
    const { login, isAuthenticaded } = useAuth();
    const navigate = useNavigate();

    useEffect(() => {
        if (isAuthenticaded) {
            navigate("/dashboard");
        }
    }, [isAuthenticaded, navigate]);




    const handleLogin = async (event: React.FormEvent<HTMLFormElement>) => {

        event.preventDefault();

        try {
            await login(username, password);

        }
        catch (error) {
            console.error(error);
            setError("Login Failed")
        }
    };

    return (
        <div className="flex items-center justify-center h-full w-full">
            <Card className="w-full h-full border-0 md:border shadow-none md:shadow-sm flex flex-col rounded-xl md:rounded-none md:rounded-r-xl">

                <div className="flex flex-col justify-center h-full">
                    <CardHeader className="space-y-1 pb-6">
                        <CardTitle className="text-2xl font-bold">Sign In</CardTitle>
                    </CardHeader>
                    <CardContent className="px-6 pb-4 flex-grow">
                        <form onSubmit={handleLogin} className="flex flex-col h-full justify-center">
                            <div className="grid w-full items-center gap-4">
                                <div className="flex flex-col space-y-1.5">
                                    <Label htmlFor="email">Username</Label>
                                    <Input
                                        id="username"
                                        type="username"
                                        placeholder="Enter your email"
                                        value={username}
                                        onChange={(e) => setUsername(e.target.value)}
                                        required
                                    />
                                </div>
                                <div className="flex flex-col space-y-1.5">
                                    <Label htmlFor="password">Password</Label>
                                    <Input
                                        id="password"
                                        type="password"
                                        placeholder="Enter your password"
                                        value={password}
                                        onChange={(e) => setPassword(e.target.value)}
                                        required
                                    />
                                </div>
                            </div>
                            <Button className="w-full mt-6" type="submit">
                                Sign In
                            </Button>
                        </form>
                    </CardContent>
                    <CardFooter className="flex flex-col sm:flex-row justify-between gap-2 px-6 py-4 border-t mt-auto">
                        <Button variant="link" className="h-auto p-0" >
                            Don't have an account? Sign Up
                        </Button>
                        <Button variant="link" className="h-auto p-0">
                            Forgot password?
                        </Button>
                    </CardFooter>
                </div>

                {error}
            </Card>
        </div>
    );
}