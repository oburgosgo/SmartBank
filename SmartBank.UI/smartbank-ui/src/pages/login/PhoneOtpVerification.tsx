import { useState } from "react";
import { Button } from "../../components/ui/Button";
import { CardContent, CardHeader, CardTitle } from "../../components/ui/Card";
import { Input } from "../../components/ui/Input";
import { Label } from "../../components/ui/Label";

interface PhoneOtpVerificationProps {
    phoneNumber: string
}

export default function PhoneOtpVerification({ phoneNumber }: PhoneOtpVerificationProps) {

    const [otp, setOtp] = useState("");
    const [otpSent, setOtpSent] = useState(false);

    const handleSentOtp = () => {
        setOtpSent(true);
    }

    return (
        <div className="flex flex-col justify-center h-full">
            <CardHeader className="space-y-1 pb-6">
                <CardTitle className="text-2xl font-bold">Phone Verification</CardTitle>
            </CardHeader>
            <CardContent className="px-6 pb-8 flex-grow flex flex-col justify-center">
                {!otpSent ? (
                    <div className="grid w-full items-center gap-4">
                        <p>We will send a verification code to: {phoneNumber}</p>
                        <Button onClick={handleSentOtp}>Send OTP</Button>
                    </div>
                ) : (
                    <div className="grid w-full items-center gap-4">
                        <div className="flex flex-col space-y-1.5">
                            <Label htmlFor="otp">OTP</Label>
                            <Input
                                id="otp"
                                type="text"
                                placeholder="Enter the OTP"
                                value={otp}
                                onChange={(e) => setOtp(e.target.value)}
                                required
                            />
                        </div>
                        <Button className="mt-2">
                            Verify OTP
                        </Button>
                    </div>
                )}
            </CardContent>
        </div>
    );
}